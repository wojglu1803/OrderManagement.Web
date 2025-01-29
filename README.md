OrderManagement.Web

Opis projektu:
OrderManagement.Web to aplikacja webowa stworzona w technologii ASP.NET MVC. Umożliwia zarządzanie zamówieniami, klientami oraz produktami, oferując funkcje CRUD (tworzenie, odczyt, aktualizacja, usuwanie). Aplikacja wspiera również uwierzytelnianie użytkowników oraz ich autoryzację z wykorzystaniem ASP.NET Identity.

Wymagania:
- System operacyjny: Windows 10 lub nowszy
- Środowisko programistyczne: Visual Studio 2022 lub nowszy
- Framework: .NET 6.0 lub nowszy
- Baza danych: SQLite

Instalacja:
1. Klonowanie repozytorium:
  - Sklonuj repozytorium na swój lokalny komputer
2. Przywrócenie pakietów NuGet
  - Otwórz projekt w Visual Studio i w Konsoli Menedżera Pakietów uruchom: dotnet restore
3. Konfiguracja bazy danych:
  - W pliku appsettings.json skonfiguruj łańcuch połączenia z bazą danych: "ConnectionStrings": { 
                                                                                                  "DefaultConnection": "Data Source=OrderManagement.db"
                                                                                                }
  - Zastosuj migracje, aby utworzyć bazę danych:  dotnet ef database update --context ApplicationDbContext
                                                  dotnet ef database update --context OrderDbContext
4. Uruchomienie aplikacji:
  - Uruchom aplikację w Visual Studio, wybierając odpowiedni profil uruchomieniowy.


Funkcje aplikacji:

1. Strona główna:
  - Po uruchomieniu aplikacji dostępne są opcje logowania i rejestracji. Po zalogowaniu użytkownik uzyskuje dostęp do funkcji zarządzania zamówieniami, klientami oraz produktami.

2. Zarządzanie zamówieniami:
  - Wyświetlanie zamówień: Lista zamówień z informacjami o dacie i kliencie.
  - Dodawanie zamówienia: Wybór klienta i przypisywanie produktów do zamówienia.
  - Szczegóły zamówienia: Wyświetlanie produktów w zamówieniu.
  - Edycja i usuwanie zamówień.
    
3. Zarządzanie klientami:
  - Lista klientów: Wyświetlanie wszystkich klientów.
  - Dodawanie nowego klienta.
  - Edycja i usuwanie klientów.
    
4. Zarządzanie produktami
  - Lista produktów: Wyświetlanie produktów z cenami i jednostkami.
  - Dodawanie nowego produktu: Podanie nazwy, ceny oraz jednostki (sztuki lub kilogramy).
  - Edycja i usuwanie produktów.
    
5. Uwierzytelnianie i autoryzacja:
  - Obsługa rejestracji i logowania użytkowników.
    
6. Custom Middleware:
  - Aplikacja wykorzystuje własne Middleware do logowania żądań HTTP w konsoli deweloperskiej.

7. API Web:
  - Dostępne jest API Web umożliwiające zewnętrzne operacje na zamówieniach.

8. Testy jednostkowe:
  - Aplikacja zawiera testy jednostkowe napisane w NUnit, pozwalające na weryfikację poprawności funkcjonalności.

9. Konfiguracja:
  - Łańcuch połączenia z bazą danych
  - Łańcuch połączenia znajduje się w pliku appsettings.json w sekcji ConnectionStrings. Możesz dostosować ścieżkę do pliku bazy danych SQLite.

!Uwagi!
1.Przed pierwszym uruchomieniem upewnij się, że wszystkie migracje zostały zastosowane.

2.W przypadku problemów z logowaniem sprawdź konfigurację łańcucha połączenia w pliku appsettings.json.


Licencja:
  - Projekt udostępniany jest na licencji MIT.
