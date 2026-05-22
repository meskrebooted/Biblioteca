using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        private readonly object _bloccoCasuale = new object();
        private readonly Random _casuale = new Random();
        private readonly List<LibroCatalogo> _catalogoBase = new List<LibroCatalogo>();
        private readonly string[] _utenti = { "Aaron", "Modou", "Burro", "Abid", "Modou", "Rayen", "Hector", "Amme", "Darid", "Singh" };
        private readonly string[] _titoli;

        private BlockingCollection<RichiestaPrestito> _codaRichieste;
        private readonly List<RichiestaPrestito> _richiesteVisibili = new List<RichiestaPrestito>();
        private readonly object _bloccoRichiesteVisibili = new object();
        private BindingList<LibroCatalogo> _catalogo;
        private CancellationTokenSource _produttoriCts;
        private CancellationTokenSource _consumatoriCts;
        private readonly CancellationTokenSource _rientriCts = new CancellationTokenSource();
        private readonly List<Task> _attivitaProduttori = new List<Task>();
        private readonly List<Task> _attivitaConsumatori = new List<Task>();
        private int _prossimoIdRichiesta = 0;
        private int _conteggioElaborate = 0;
        private int _ritardoProduttoriMin = 1500;
        private int _ritardoProduttoriMax = 3000;
        private int _ritardoConsumatoriMin = 2000;
        private int _ritardoConsumatoriMax = 3500;
        private const int NumeroProduttoriPredefinito = 2;
        private const int NumeroConsumatoriPredefinito = 2;
        private bool _simulazioneAttiva = false;
        private ProfiloVelocita _profiloVelocita = ProfiloVelocita.Media;

        public Form1()
        {
            InitializeComponent();
            _titoli = SeedCatalog();
            InitializeQueue();
            BindCatalog();
            UpdateQueueView();
            UpdateStatus();
            UpdateSimulationState(false);
            ImpostaVelocita(ProfiloVelocita.Media);
        }

        private string[] SeedCatalog()
        {
            _catalogoBase.Clear();
            _catalogoBase.Add(new LibroCatalogo("Il nome della rosa", 5));
            _catalogoBase.Add(new LibroCatalogo("I promessi sposi", 4));
            _catalogoBase.Add(new LibroCatalogo("Il piccolo principe", 6));
            _catalogoBase.Add(new LibroCatalogo("Cent'anni di solitudine", 3));
            _catalogoBase.Add(new LibroCatalogo("La coscienza di Zeno", 2));
            _catalogoBase.Add(new LibroCatalogo("Diario Della schiappa", 4));

            var titoli = new List<string>();
            foreach (var item in _catalogoBase)
            {
                titoli.Add(item.Titolo);
            }
            return titoli.ToArray();
        }

        private void InitializeQueue()
        {
            _codaRichieste = new BlockingCollection<RichiestaPrestito>(new ConcurrentQueue<RichiestaPrestito>());
        }

        private void BindCatalog()
        {
            _catalogo = new BindingList<LibroCatalogo>();
            foreach (var item in _catalogoBase)
            {
                _catalogo.Add(new LibroCatalogo(item.Titolo, item.Totale));
            }
            RefreshBookCards();
        }

        private void btnToggleSimulation_Click(object sender, EventArgs e)
        {
            if (_simulazioneAttiva)
            {
                StopProducers();
                StopConsumers();
                UpdateSimulationState(false);
                return;
            }

            StartProducers(NumeroProduttoriPredefinito);
            StartConsumers(NumeroConsumatoriPredefinito);
            UpdateSimulationState(true);
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            AddRequest(CreateRandomRequest("UI"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProducers();
            StopConsumers();
            _rientriCts.Cancel();
            _codaRichieste?.CompleteAdding();
        }

        private void StartProducers(int count)
        {
            StopProducers();
            _produttoriCts = new CancellationTokenSource();
            _attivitaProduttori.Clear();

            // Avvia task in background che generano richieste.
            for (int i = 0; i < count; i++)
            {
                int producerId = i + 1;
                var attivita = Task.Run(() => ProducerLoop(producerId, _produttoriCts.Token), _produttoriCts.Token);
                _attivitaProduttori.Add(attivita);
            }

        }

        private void StopProducers()
        {
            if (_produttoriCts == null)
            {
                return;
            }

            _produttoriCts.Cancel();
            _produttoriCts = null;
        }

        private void StartConsumers(int count)
        {
            StopConsumers();
            _consumatoriCts = new CancellationTokenSource();
            _attivitaConsumatori.Clear();

            // Avvia task in background che consumano la coda.
            for (int i = 0; i < count; i++)
            {
                int consumerId = i + 1;
                var attivita = Task.Run(() => ConsumerLoop(consumerId, _consumatoriCts.Token), _consumatoriCts.Token);
                _attivitaConsumatori.Add(attivita);
            }

        }

        private void StopConsumers()
        {
            if (_consumatoriCts == null)
            {
                return;
            }

            _consumatoriCts.Cancel();
            _consumatoriCts = null;
        }

        private void ProducerLoop(int producerId, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // Loop su thread di lavoro: non toccare direttamente la UI.
                var richiesta = CreateRandomRequest($"P{producerId}");
                try
                {
                    _codaRichieste.Add(richiesta, token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                RegistraRichiestaVisibile(richiesta);
                SafeUiUpdate(() =>
                {
                    UpdateQueueView();
                    UpdateStatus();
                });

                Thread.Sleep(NextRandom(_ritardoProduttoriMin, _ritardoProduttoriMax));
            }
        }

        private void ConsumerLoop(int consumerId, CancellationToken token)
        {
            try
            {
                foreach (var richiesta in _codaRichieste.GetConsumingEnumerable(token))
                {
                    // Le modifiche alla UI passano dal thread principale.
                    SafeUiUpdate(() => ProcessRequestOnUi(richiesta));
                    Thread.Sleep(NextRandom(_ritardoConsumatoriMin, _ritardoConsumatoriMax));
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void ProcessRequestOnUi(RichiestaPrestito richiesta)
        {
            bool granted = false;
            var item = _catalogo.FirstOrDefault(c => c.Titolo == richiesta.Libro);
            if (item != null && item.Disponibili > 0)
            {
                item.Disponibili -= 1;
                granted = true;
                ScheduleReturn(richiesta);
                RefreshBookCards();
            }

            richiesta.Stato = granted ? StatoRichiesta.Approvata : StatoRichiesta.Rifiutata;
            _conteggioElaborate++;
            UpdateQueueView();
            UpdateStatus();

            var status = granted ? "APPROVATA" : "RIFIUTATA";
            var message = $"{DateTime.Now:HH:mm:ss} | Richiesta #{richiesta.Id} | Utente: {richiesta.Utente} | Libro: {richiesta.Libro} | Esito: {status}";
            listLog.Items.Insert(0, message);
            PianificaRimozioneRichiesta(richiesta);
        }

        private void ScheduleReturn(RichiestaPrestito richiesta)
        {
            int delayMs = NextRandom(4000, 9000);
            var token = _rientriCts.Token;

            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(delayMs, token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }

                SafeUiUpdate(() => ReturnBookOnUi(richiesta));
            }, token);
        }

        private void ReturnBookOnUi(RichiestaPrestito richiesta)
        {
            var item = _catalogo.FirstOrDefault(c => c.Titolo == richiesta.Libro);
            if (item != null && item.Disponibili < item.Totale)
            {
                item.Disponibili += 1;
                UpdateStatus();
                RefreshBookCards();
                var message = $"{DateTime.Now:HH:mm:ss} | Rientro | Richiesta #{richiesta.Id} | Libro: {richiesta.Libro}";
                listLog.Items.Insert(0, message);
            }
        }

        private void AddRequest(RichiestaPrestito richiesta)
        {
            if (_codaRichieste.IsAddingCompleted)
            {
                return;
            }

            _codaRichieste.Add(richiesta);
            RegistraRichiestaVisibile(richiesta);
            UpdateQueueView();
            UpdateStatus();
        }

        private RichiestaPrestito CreateRandomRequest(string fonte)
        {
            var utente = _utenti[NextRandom(0, _utenti.Length)];
            var libro = _titoli[NextRandom(0, _titoli.Length)];
            int id = Interlocked.Increment(ref _prossimoIdRichiesta);
            return new RichiestaPrestito(id, utente, libro, fonte, DateTime.Now);
        }

        private int NextRandom(int min, int max)
        {
            lock (_bloccoCasuale)
            {
                return _casuale.Next(min, max);
            }
        }

        private void UpdateQueueView()
        {
            List<RichiestaPrestito> richieste;
            lock (_bloccoRichiesteVisibili)
            {
                richieste = _richiesteVisibili.ToList();
            }
            listQueue.BeginUpdate();
            listQueue.Items.Clear();
            foreach (var richiesta in richieste)
            {
                var row = new ListViewItem(richiesta.Id.ToString());
                row.SubItems.Add(richiesta.Utente);
                row.SubItems.Add(richiesta.Libro);
                row.SubItems.Add(richiesta.DataCreazione.ToString("HH:mm:ss"));
                row.SubItems.Add(richiesta.Fonte);
                ApplicaStileRiga(row, richiesta.Stato);
                listQueue.Items.Add(row);
            }
            listQueue.EndUpdate();
        }

        private static void ApplicaStileRiga(ListViewItem row, StatoRichiesta stato)
        {
            switch (stato)
            {
                case StatoRichiesta.Approvata:
                    row.BackColor = Color.FromArgb(200, 245, 200);
                    row.ForeColor = Color.FromArgb(30, 70, 30);
                    break;
                case StatoRichiesta.Rifiutata:
                    row.BackColor = Color.FromArgb(255, 210, 210);
                    row.ForeColor = Color.FromArgb(150, 0, 0);
                    break;
                default:
                    row.BackColor = Color.FromArgb(255, 249, 196);
                    row.ForeColor = Color.FromArgb(80, 60, 0);
                    break;
            }
        }

        private void RegistraRichiestaVisibile(RichiestaPrestito richiesta)
        {
            lock (_bloccoRichiesteVisibili)
            {
                _richiesteVisibili.Add(richiesta);
            }
        }

        private void RimuoviRichiestaVisibile(int id)
        {
            lock (_bloccoRichiesteVisibili)
            {
                for (int i = _richiesteVisibili.Count - 1; i >= 0; i--)
                {
                    if (_richiesteVisibili[i].Id == id)
                    {
                        _richiesteVisibili.RemoveAt(i);
                    }
                }
            }
        }

        private void PianificaRimozioneRichiesta(RichiestaPrestito richiesta)
        {
            // Mantiene la riga visibile per qualche secondo dopo l'elaborazione.
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(5000, _rientriCts.Token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }

                SafeUiUpdate(() =>
                {
                    RimuoviRichiestaVisibile(richiesta.Id);
                    UpdateQueueView();
                    UpdateStatus();
                });
            }, _rientriCts.Token);
        }

        private void UpdateStatus()
        {
            lblQueueCount.Text = $"In coda: {_codaRichieste.Count}";
            lblProcessedCount.Text = $"Elaborate: {_conteggioElaborate}";
        }

        private void UpdateSimulationState(bool running)
        {
            _simulazioneAttiva = running;
            btnToggleSimulation.Text = running ? "Ferma simulazione" : "Avvia simulazione";
            lblSimulationStatus.Text = running ? "Stato: in corso" : "Stato: ferma";
        }

        private void ImpostaVelocita(ProfiloVelocita profilo)
        {
            _profiloVelocita = profilo;
            switch (profilo)
            {
                case ProfiloVelocita.Lenta:
                    _ritardoProduttoriMin = 2500;
                    _ritardoProduttoriMax = 4500;
                    _ritardoConsumatoriMin = 3000;
                    _ritardoConsumatoriMax = 5500;
                    break;
                case ProfiloVelocita.Veloce:
                    _ritardoProduttoriMin = 700;
                    _ritardoProduttoriMax = 1400;
                    _ritardoConsumatoriMin = 900;
                    _ritardoConsumatoriMax = 1600;
                    break;
                default:
                    _ritardoProduttoriMin = 1500;
                    _ritardoProduttoriMax = 3000;
                    _ritardoConsumatoriMin = 2000;
                    _ritardoConsumatoriMax = 3500;
                    break;
            }

            AggiornaStileVelocita();
        }

        private void AggiornaStileVelocita()
        {
            var selezionato = Color.FromArgb(255, 213, 79);
            var normale = Color.FromArgb(230, 230, 230);
            var testo = Color.FromArgb(40, 40, 40);

            btnVelocitaLenta.BackColor = _profiloVelocita == ProfiloVelocita.Lenta ? selezionato : normale;
            btnVelocitaMedia.BackColor = _profiloVelocita == ProfiloVelocita.Media ? selezionato : normale;
            btnVelocitaVeloce.BackColor = _profiloVelocita == ProfiloVelocita.Veloce ? selezionato : normale;

            btnVelocitaLenta.ForeColor = testo;
            btnVelocitaMedia.ForeColor = testo;
            btnVelocitaVeloce.ForeColor = testo;
        }

        private void btnVelocitaLenta_Click(object sender, EventArgs e)
        {
            ImpostaVelocita(ProfiloVelocita.Lenta);
        }

        private void btnVelocitaMedia_Click(object sender, EventArgs e)
        {
            ImpostaVelocita(ProfiloVelocita.Media);
        }

        private void btnVelocitaVeloce_Click(object sender, EventArgs e)
        {
            ImpostaVelocita(ProfiloVelocita.Veloce);
        }

        private void RefreshBookCards()
        {
            panelBooks.SuspendLayout();
            panelBooks.Controls.Clear();
            foreach (var item in _catalogo)
            {
                panelBooks.Controls.Add(new SchedaLibro(item));
            }
            panelBooks.ResumeLayout();
        }

        private void SafeUiUpdate(Action action)
        {
            if (IsDisposed || !IsHandleCreated)
            {
                return;
            }

            // Evita accessi cross-thread alla UI.
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private enum ProfiloVelocita
        {
            Lenta,
            Media,
            Veloce
        }
    }

 
}
