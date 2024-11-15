# Progetto CardMarket

Un sistema distribuito per la gestione di un sito di vendita di carte da gioco, progettato per offrire funzionalità di gestione annunci, pagamenti, recensioni e autenticazione utenti, utilizzando un'architettura a microservizi e Kafka per la comunicazione tra i servizi.

---

## 🚀 Funzionalità Principali

1. **Gestione Annunci**  
   Permette di aggiungere, cercare e rimuovere annunci di carte e inserzioni.
   
2. **Gestione Transazioni**  
   Offre strumenti per la gestione dei pagamenti relativi alle inserzioni.

3. **Gestione Recensioni**  
   Consente di creare, cercare e rimuovere recensioni delle transazioni.

4. **Autenticazione Utenti**  
   Gestisce gli accessi e i ruoli (utente e admin).

---

## 📋 Requisiti

- **Docker** e **Docker Compose**  
- Kafka per la gestione della comunicazione tra i microservizi  
- Ambiente operativo: Linux/MacOS/Windows con terminale abilitato

---

## 🛠️ Installazione

1. **Scarica il progetto**  
   Estrarre il contenuto della repository in una directory di lavoro.

2. **Avviare i microservizi**  
   Aprire un terminale nella directory `Docker` ed eseguire i comandi:
   ```bash
   docker compose build
   docker compose up -d
   
---

3. **Accesso e autenticazione**  
   Collegarsi alla porta dedicata al servizio di autenticazione (specificata nel file `docker-compose.yml`). Utilizzare uno degli account predefiniti o crearne uno nuovo.

| ID                | Password   |
|-------------------|------------|
| utente1@gmail.com | Test1234!  |
| utente2@gmail.com | Test1234!  |
| utente3@gmail.com | Test1234!  |
| admin@gmail.com   | Test1234!  |


## 🏗️ Architettura
| Producer       | Consumer              |
|----------------|-----------------------|
| annunci        | inserzioni, utenti    |
| recensioni     | utenti                |
| pagamenti      | annunci               |
| transazioni    | pagamenti             |
| autenticazione | utenti                |

---

## 📂 Microservizi

### 1. Annunci
- **Aggiunta Carta** (Admin)
- **Ricerca di una carta** tramite stringa
- **Aggiunta Inserzione**
- **Rimozione Inserzione**
- **Ricerca Inserzione** tramite:
  - Carta
  - Carta e rarità
  - ID utente
- **Aggiunta Rarità** (Admin)
- **Ricerca Rarità**

---

### 2. Transazioni
- **Aggiunta Pagamento**
- **Ricerca Pagamenti**:
  - Dell'utente loggato
  - Di un utente specifico (Admin)
  - Tramite metodo di pagamento (Admin)
  - Tramite stato del pagamento (Admin)

---

### 3. Recensioni
- **Aggiunta Recensione**
- **Rimozione Recensione** (solo proprietario o Admin)
- **Ricerca Recensioni**:
  - Prodotte da un acquirente
  - Ricevute da un venditore
  - Venditori con media voti superiore a una soglia

---

### 4. Autenticazione
Gestisce l'accesso e il controllo degli utenti. È un servizio essenziale per il funzionamento degli altri microservizi.

