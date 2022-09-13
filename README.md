# MyFactoryMVC

ASP.NET Core Web App (Model-View-Controller)
Freamework version: .NET 5.0
Autentification Type: Individual Accounts

Aplikacija predstavlja jednostavnu simulaciju za vođenje tvornice.
Prilikom pokretanja aplikacije, korisnika doćekuje Log in stranica. Korisnik s postojećim i validnim računom može se prijaviti, dok korisnik koji nije u sustavu mora odraditi registraciju.
Za potrebe registracije novog korisnika osim default emaila i Passworda dodan je unos imena i prezimena korisnika. Format emaila i passworda osigurana je ugrađenim svojstvima Individual Accounts-a.
U aplikaciju nije ugrađen validator emaila.
Prijavljenom korisniku onemogućeno je korištenje aplikacije dok mu se ne dodijeli rola.
Apliakcija podržava 3 glavne role: Skladištar, Radnik i Adminsitrator

SUPERADMIN je osoba sa svim privilegijama i pravima pristupa unutar aplikacije.

Administator svakom novom registriranom korisniku dodaje rolu jer on ima pristup User Roles. Nakon što je korisniku dodijeljena rola, on može pristupiti dijelu aplikacije za koji ima prava.

Pravo (rola) skaldištara omogućuje korisniku da u skladište unosi materijale (Materials) koji će se korisniti prilikom kreiranja proizvoda. Kako bi se mogla pridijeliti mjerna jedinica uz proivod, skladištar ima i dozvolu kreiranja mjerne jedinice (MesureUnits).
Pravo (rola) radnika omogućuje korisniku da kreira proizvod (Products) koji bi tvornica mogla proizvesti. Isto tako ima pristup popisu materijala koji su potrebni da bi se taj prozvod proizveo(Materials on Project) i  može pridodati materijal proizvodu (Asign Materials)
Pravo (rola) admina omogućuje prodadavanje rola korisniku (User Roles)
