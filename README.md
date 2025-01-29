OrderManagement.Web
Opis projektu
OrderManagement.Web to aplikacja webowa stworzona w technologii ASP.NET MVC. Umożliwia zarządzanie zamówieniami, klientami oraz produktami, oferując funkcje CRUD (tworzenie, odczyt, aktualizacja, usuwanie). Aplikacja wspiera również uwierzytelnianie użytkowników oraz ich autoryzację z wykorzystaniem ASP.NET Identity.

Wymagania
System operacyjny: Windows 10 lub nowszy
Środowisko programistyczne: Visual Studio 2022 lub nowszy
Framework: .NET 6.0 lub nowszy
Baza danych: SQLite
Instalacja
1. Klonowanie repozytorium
Sklonuj repozytorium na swój lokalny komputer:

bash
Kopiuj
Edytuj
git clone https://github.com/TwojeRepozytorium/OrderManagement.Web.git
2. Przywrócenie pakietów NuGet
Otwórz projekt w Visual Studio i w Konsoli Menedżera Pakietów uruchom:

bash
Kopiuj
Edytuj
dotnet restore
3. Konfiguracja bazy danych
W pliku appsettings.json skonfiguruj łańcuch połączenia z bazą danych:

json
Kopiuj
Edytuj
"ConnectionStrings": {
  "DefaultConnection": "Data Source=OrderManagement.db"
}
Zastosuj migracje, aby utworzyć bazę danych:

bash
Kopiuj
Edytuj
dotnet ef database update --context ApplicationDbContext
dotnet ef database update --context OrderDbContext
4. Uruchomienie aplikacji
Uruchom aplikację w Visual Studio, wybierając odpowiedni profil uruchomieniowy.

Funkcje aplikacji
Strona główna
Po uruchomieniu aplikacji dostępne są opcje logowania i rejestracji. Po zalogowaniu użytkownik uzyskuje dostęp do funkcji zarządzania zamówieniami, klientami oraz produktami.

Zarządzanie zamówieniami
Wyświetlanie zamówień: Lista zamówień z informacjami o dacie i kliencie.
Dodawanie zamówienia: Wybór klienta i przypisywanie produktów do zamówienia.
Szczegóły zamówienia: Wyświetlanie produktów w zamówieniu.
Edycja i usuwanie zamówień.
Zarządzanie klientami
Lista klientów: Wyświetlanie wszystkich klientów.
Dodawanie nowego klienta.
Edycja i usuwanie klientów.
Zarządzanie produktami
Lista produktów: Wyświetlanie produktów z cenami i jednostkami.
Dodawanie nowego produktu: Podanie nazwy, ceny oraz jednostki (sztuki lub kilogramy).
Edycja i usuwanie produktów.
Uwierzytelnianie i autoryzacja
Obsługa rejestracji i logowania użytkowników.
Role użytkowników:
Administrator: Pełny dostęp do wszystkich funkcji oraz możliwość zarządzania użytkownikami.
Użytkownik: Ograniczony dostęp.
Custom Middleware
Aplikacja wykorzystuje własne Middleware do logowania żądań HTTP w konsoli deweloperskiej.

API Web
Dostępne jest API Web umożliwiające zewnętrzne operacje na zamówieniach.

Testy jednostkowe
Aplikacja zawiera testy jednostkowe napisane w NUnit, pozwalające na weryfikację poprawności kluczowych funkcjonalności.

Konfiguracja
Łańcuch połączenia z bazą danych
Łańcuch połączenia znajduje się w pliku appsettings.json w sekcji ConnectionStrings. Możesz dostosować ścieżkę do pliku bazy danych SQLite.

Tworzenie konta administratora
Po uruchomieniu aplikacji można zalogować się jako administrator. W celu dodania konta administracyjnego należy postępować zgodnie z instrukcjami w sekcji "Użytkownicy".

Testowi użytkownicy
Przy pierwszym uruchomieniu aplikacji można zarejestrować nowe konto użytkownika. Administrator ma możliwość przypisywania ról innym użytkownikom.

Uwagi
Przed pierwszym uruchomieniem upewnij się, że wszystkie migracje zostały zastosowane.
W przypadku problemów z logowaniem sprawdź konfigurację łańcucha połączenia w pliku appsettings.json.
Licencja
Projekt udostępniany jest na licencji MIT.
