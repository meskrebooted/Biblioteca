# Biblioteca

## Cos'è
Applicazione Windows Forms che simula una biblioteca con richieste di prestito. I produttori generano richieste, i consumatori le elaborano, il catalogo aggiorna le disponibilità e il log mostra gli eventi principali. La UI evidenzia lo stato delle richieste con colori.

## Componenti principali
- **Form1.cs**: logica dell'app (coda, simulazione, UI).
- **ModelliPrestiti.cs**: modelli dati (`RichiestaPrestito`, `LibroCatalogo`) e stato richiesta.
- **SchedaLibro.cs**: disegno grafico delle card dei libri.
- **Form1.Designer.cs**: layout e stile dei controlli.

## Flusso di funzionamento
1. I produttori creano richieste e le inseriscono nella coda.
2. I consumatori prelevano le richieste e provano a soddisfarle.
3. La UI viene aggiornata solo dal thread principale.
4. Il log registra approvazioni, rifiuti e rientri.

## Funzioni thread principali
- **ProducerLoop / ConsumerLoop**: thread di lavoro che producono e consumano richieste dalla coda.
- **SafeUiUpdate**: aggiorna la UI dal thread principale evitando errori cross‑thread.
- **ScheduleReturn**: avvia un task con `Task.Delay` per simulare il rientro dei libri.
- **PianificaRimozioneRichiesta**: usa un task con ritardo per rimuovere la riga dalla coda dopo l'elaborazione.
