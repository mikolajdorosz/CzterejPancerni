using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzterejPancerni
{
    internal class Story
    {
        public static void Prologue()
        {
            Components.Title();
            Console.Write(
                "\n\nWitaj! Pozwól, że się przedstawimy. Nazywam się Jan Kos, ten tutaj, wysoki to Gustaw Jeleń, a ten ostatni, co przy \"Rudym\" majstruje, to Grigorij Saakaszwili... Teraz do rzeczy. Nasz dowódca został ranny i szukamy kogoś na jego miejsce. Bez czwartego załoganta nasza misja się nie powiedzie. " +
                "-Spacja-");
            Utilities.OnSpacebar();
            Console.Clear();
            Components.Title();
            Console.Write(
                "\nMój pies, Szarik, jest w opałach. Potrzebujemy kogoś doświadczonego i zaprawionego w boju, aby odzyskać naszego pupila. Mam nadzieję, że skoro już tu jesteś, to nam pomożesz, prawda? Świetnie! Tak właśnie myslałem. A więc... Witaj w kompanii! " +
                "Jak się do ciebie zwracać Dowódco? ");
            Game.Player = Console.ReadLine().Trim();
            Console.WriteLine(
                "Tak jest Dowódco {0}! Pozwól, że opiszę Ci całą sytuację..." +
                "-Spacja-", Game.Player);
            Utilities.OnSpacebar();
            Console.Clear();
            Components.Title();
            Console.Write(
                "\nSzarik uciekał przed szturmującymi oddziałami Niemców. Szczęśliwie zdołał ominąć wszystkie, lecące w naszą stronę, kule. Ukrył się w norze, jaka powstała pomiędzy korzeniami wyrwanego, na skutek wybuchu miny, dębu. Niestety szybko okazało się, że kryjówka, mimo że skuteczna, została otoczona przez oddziały wroga. Szarik znalazł się w pułapce! " +
                "-Spacja-", Game.Player);
            Utilities.OnSpacebar();
            Console.Clear();
            Components.Title();
            Console.Write(
                "\nDowódco {0}, Twoim zadaniem, jest ODZYSKANIE SZARIKA." +
                "\nPodczas drogi napotkasz na przeszkody. Zachowaj zimną krew, bądź gotów na każdą ewentualność. Pamiętaj, że im dłużej zwlekasz z podjęciem decyzji, tym mniejsza szansa na odzyskanie Szarika! " +
                "-Spacja-", Game.Player);
            Utilities.OnSpacebar();
            Console.Clear();
        }

        public static string CollapsedBridge(string message)
        {
            if (message == "BeforeCheck") return
                "\nPrzeszkoda: ZAWALONY MOST." +
                "\nDowódco {0}, zaglądnij do ekwipunku 'q'. Może jest tam przedmiot, który ułatwi pokonanie tej przeszkody.\n";
            else if (message == "BeforeChoice") return
                "\nTwoja załoga, już na początku misji, została zatrzymana. Tam, gdzie kiedyś stał most, leżała jedynie sterta gruzu." +
                "\nDowódco {0}, czekamy na rozkazy!";
            else if (message == "Choice1") return
                "\n1 - Łapcie za łopaty i wyrównajcie uskok! Jak skończycie ruszamy dalej...";
            else if (message == "Choice2") return
                "\n2 - Gdzieś w pobliżu musi być inna droga. Łapcie za mapę i jazda!";
            else if (message == "Choice3") return
                "\n3 - Z wozu! Szkoda czasu, dalej ruszamy pieszo.";
            else if (message == "Option1") return
                "\n\nZałoga natychmiast wzięła się do roboty. W dole stał, ciężki pojazd pancerny, wokół którego leżało mnóstwo przedmiotów. Janek nie mógł przjść obok nich oojętnie, dzięki czemu zgarnął zestaw narzędzi. Powodem zawalenia mostu, jak stwierdził napotakany przy nim chłopak, był stojący na dnie opuszczony pojazd. Młodzieniec z chęcią pomógł żołnierzom, miał nadzieję, że załapie się na przejażdżkę czołgiem... " +
                "-Spacja-";
            else if (message == "Option2Challenge") return
                "\nAby znaleźć alternatywną drogę, najpierw musisz zlokalizować swoją pozycję. Nie jest to takie proste na jakie mogłoby się wydawać. Mapa zawilgła, przez co została lekko podarta. Jej odczytanie jest uwarunkowane prawidłową odpowiedzią na poniższe pytanie." +
                "\nJak nazywa się serial, w którym zagrał Szarik? ";
            else if (message == "CorrectAnswer") return
                "\n\nPo wnikliwej analizie szczątków mapy załodze w końcu udało się odnaleźć inną drogę, prowadziła przez las. Wśród kamieni leżały rozrzucone narzędzia, co wskazywałoby, że nie tylko oni szukali alternatywnej ścieżki. Za lasem natknęli się na sojuszniczy oddział, który stacjonował na skraju pola minowego. Żołnierze chcieli przedrzeć się przez tę przeszkodę. Od dłuższego czasu analizowali wszystkie możliwe ścieżki, dlatego w momencie, gdy załoga się do nich zbilżała, wiedzieli już, którą wybrać. " +
                "-Spacja-";
            else if (message == "WrongAnswer") return
                "\n\nNiestety z czarnych chmur, nagle zaczął padać deszcz, przez co mapa stała się całkowicie nieczytelna. Załoga, nie znając okolicy zabłądziła. Tymczasem jeden z Niemców odnalazł Szarika w jego kryjówce. Zastrzelił psa, myśląc, że to wilk. " +
                "-Spacja-";
            else if (message == "Option3") return
                "\n\nCała załoga, z wyjątkiem Grigorija, który postanowił poszukać innej drogi, natychmiast opuściła czołg. W dole stał, ciężki pojazd pancerny, wokół którego leżało mnóstwo przedmiotów. Janek nie mógł przjść obok nich oojętnie, dzięki czemu zgarnął zestaw narzędzi oraz wykrywacz min. " + 
                "-Spacja-";
            return "";
        }

        public static string MineField(string message)
        {
            if (message == "BeforeCheck") return
                "\nPrzeszkoda: POLE MINOWE." +
                "\nDowódco {0}, zaglądnij do ekwipunku 'q'. Może jest tam przedmiot, który ułatwi pokonanie tej przeszkody.\n";
            else if (message == "BeforeChoice") return
                "\nTwoja załoga ponownie została zatrzymana. Tym razem droga zaprowadziła was przed pole minowe. Jeden niewłaściwy ruch może spowodować katastrofę." +
                "\nDowódco {0}, czekamy na rozkazy!";
            else if (message == "Choice1") return
                "\n1 - Janek, rzuć Gustlikowi wykrywacz min!";
            else if (message == "Choice2") return
                "\n2 - Grigorij, wierzę w ciebie!";
            else if (message == "Choice3") return
                "\n3 - Franek, ty zapewne znasz okolicę...";
            else if (message == "Option1") return
                "\n\nGustlik, który jako jedyny miał wcześniej do czynienia z takim narzędziem, prowadził kompanów. Dokoła leżało pełno ciał, zarówno sojuszników, jak i wrogów. Jankowi udało się zgarnąć karabin, który leżał nieopodal jednego z mijanych trupów. " +
                "-Spacja-";
            else if (message == "Option2Challange") return
                "\nGrigorij ani przez chwilę się nie zawahał. Pomimo świadomości, że niemożliwe jest, aby nieuszkodzić pojazdu, uruchamił silnik i ruszył naprzód. Przejazd przez pole minowe jest uwarunkowany prawidłową odpowiedzią na poniższe pytanie." +
                "\nJak Janek Kos nazwał swojego psa? ";
            else if (message == "CorrectAnswer") return 
                "\n\nGrigorij dokonał niemożliwego! " +
                "-Spacja-";
            else if (message == "WrongAnswer") return
                "\n\nPodczas przejazdu przez pole, Grigorij rozprasza się hukiem wystrzału i najeżdża na minę. Czołg został unieruchomiony. Jego naprawa pośrodku pola minowego byłaby ogromnie ryzykowna. Załoga nie decyduje się na dalszą przeprawę, szuka innej drogi. Trwa to jednak zbyt długo. Tymczasem jeden z Niemców odnalazł Szarika w jego kryjówce. Zastrzelił psa, myśląc, że to wilk. " +
                "-Spacja-";
            else if (message == "Option3") return 
                "\n\nFranek, mimo, że musiał już opuścić kompanię, przedtem z chęcią pomógł załodze w przedarciu przez pole minowe. Chłopak wiele razy przez nie przechodził, więc znał bezpieczną ścieżkę. Nakręślił ją na papierze i wręczył w Twoje ręce. Załoga musiała zostawić czołg, nie było opcji, aby precyzyjnie manewrować pomiędzy minami tak wielkim pojazdem. Grigorij, nie chcąc pozostawić czołgu, zaczął szukać innej trasy. " +
                "-Spacja-";
            return "";
        }

        public static string TankFailue(string message)
        {
            switch (message)
            {
                case "BeforeCheck": return
                    "\nPrzeszkoda: AWARIA CZOŁGU." +
                    "\nDowódco {0}, zaglądnij do ekwipunku 'q'. Może jest tam przedmiot, który ułatwi pokonanie tej przeszkody.\n";
                case "BeforeChoice": return
                    "\nPrzejeżdżając przez pole minowe, Grigorij rozproszył sie hukiem wystrzału. Kierowca utracił kontrolę nad czołgiem i najechał na minę. Zniszczyła ona gąsienicę, przez co dalsza jazda była niemożliwa." +
                    "\nDowódco {0}, czekamy na rozkazy!";
                case "Choice1": return
                    "\n1 - Grigorij, bierz narzędzia i do roboty! Czołg będzie nam jeszcze potrzebny.";
                case "Choice2": return
                    "\n2 - Z wozu! Szkoda czasu, liczy się każda sekunda!";
                case "Option1Challenge": return
                    "\nAby naprawić usterkę, Grigorij potrzebuje klucz francuski. Od 5 min przeczesuje zestaw z narzędziami, jednak nie może go znaleźć. Znalezienie klucza jest uwarunkowane prawidłową odpowiedzią na poniższe pytanie." +
                    "\nJak nazywa się pierwsza przeszkoda? ";
                case "CorrectAnswer": return
                    "\n\n'Nareszcie! Znalazłem ten przeklęty klucz.' - krzyknął. Grigorij jest świetnym mechanikiem, więc szybko poradził sobie z uszkodzeniem. Załoga może jechać dalej. " +
                    "-Spacja-";
                case "WrongAnswer": return
                    "\n\n'Nic z tego nie będzie!' - melduje - 'Uszkodzenie jest zbyt poważne, aby uporać się z nim w takich warunkach'. Załodze pozostało opuścić pojazd, zostawić część broni i ruszyć pieszo. " +
                    "-Spacja-";
                case "Option2": return
                    "\n\nZałodze pozostało opuścić pojazd, zostawić część broni i ruszyć pieszo.";
                default:
                    return "";
            }
        }

        public static string Enemy(string message)
        {
            switch (message)
            {
                case "BeforeCheck": return
                    "\nPrzeszkoda: WRÓG NA DRODZE." +
                    "\nDowódco {0}, zaglądnij do ekwipunku 'q'. Może jest tam przedmiot, który ułatwi pokonanie tej przeszkody.\n";
                case "BeforeChoice": return
                    "\nZałoga jest już bardzo blisko, uratowania Szarika. Z oddali słychać już wojsko Niemieckie. Nagle zza zakrętu wyłanił się oddział wroga." +
                    "\nDowódco {0}, czekamy na rozkazy!";
                case "Choice1": return
                    "\n1 - Szybko, ukryjcie się! Weźmiemy ich z zaskoczenia...";
                case "Choice2": return
                    "\n2 - No dalej! Do ataku!";
                case "Choice3": return
                    "\n3 - Zawracamy, poszukamy bezpieczniejszej drogi.";
                case "Option1": return
                    "\n\nZdezorientowani żołnierze nie stanowili dużego wyzwania. Załoga szybko i skutecznie poradziła sobie z przeciwnikiem. Janek z Gustlikiem ogołocili zabitych z ich broni i mundurów. " +
                    "-Spacja-";
                case "Option2Challenge": return
                    "\nPrzeciwnik od razu was zobaczył. Żołnierze natychmiast przyjęli formację obronną i zaczęli do was strzelać. Pokonanie Niemców jest uwarunkowane prawidłową odpowiedzią na poniższe pytanie." +
                    "\nJak nazywał się czołg głównych bohaterów serialu? ";
                case "CorrectAnswer": return
                    "\n\nPomimo początkowego oporu, załodze udało się przełamać linię obrony i pokonać wrogów. Szczęśliwie nie ponieśli żadnych strat. Zapas amunicji skończył się bardzo szybko, przez co część broni stała się bezużyteczna. " +
                    "-Spacja-";
                case "WrongAnswer": return
                    "\n\nNiestety nie udało ci się przełamać obrony wroga. Byłeś zmuszony wydać rozkaz do odwrotu. Pomimo tego, załoga była nieustępliwa. Twoi kompani byli w amoku. Nie docierały do nich żadne słowa, walczyli do ostatniego tchu. " + 
                    "-Spacja-";
                case "Option3": return
                    "\n\nMapa, którą zostawił wam Franek, okazała się ogromnie przydatna. Bardzo szczegółowo opisywała całą okolicę, dzieki czemu, załodze udało się uniknąć konfrontacji z wrogim oddziałem. " + 
                    "-Spacja-";
                default:
                    return "";
            }
        }

        public static string BattleField(string message)
        {
            switch (message)
            {
                case "BeforeCheck": return
                    "\nPrzeszkoda: POLE WALKI." +
                    "\nDowódco {0}, zaglądnij do ekwipunku 'q'. Może jest tam przedmiot, który ułatwi pokonanie tej przeszkody.\n";
                case "BeforeChoice": return
                    "\nOkazało się, że oddział przeciwnika, na który natknęła się wcześniej załoga, nie stacjonował tutaj bez powodu. W okolicy trwały walki. Przedarcie się do kryjówki Szarika będzie dużym wyzwaniem. " +
                    "\nDowódco {0}, czekamy na rozkazy!";
                case "Choice1": return
                    "\n1 - Trzeba wesprzeć naszych! No dalej! Do boju!";
                case "Choice2":  return
                    "\n2 - Załóżmy mundury, weźmiemy ich podstępem...";
                case "Choice3": return
                    "\n3 - Biorę sprawy w swoje ręce. Osłaniajcie mnie.";
                case "Option1": return
                    "\n\nW powietrzu czuć zapach siarki i prochu. Dokoła słychać huk wystrzałów z dział i karabinów. Załoga dotarła do fortyfikacji, gdzie dzielnie bronili się Polacy. Ostatecznie udało się odeprzeć atak wroga i przejść do kontrofensywy. Dołączył do was niewielki oddział, z którego pomocą udało wam się dostać do kryjówki Szarika. " +
                    "-Spacja-";
                case "Option2": return
                    "\n\nZałodze bez trudu udało się zmylić Niemców. Od terz musieli uważać, aby to Polacy nie zaczęli do nich strzelać. Szarik na widok swoich właścicieli, radośnie zaszczekał. " +
                    "-Spacja-";
                case "Option3Challenge": return
                    "\nOd tego momentu powodzenie misji było zależne tylko od ciebie. Dotarcie do Szarika jest uwarunkowane prawidłową odpowiedzią na poniższe pytanie." +
                    "\nGdzie ukrył się Szarik? Odpowiedz w oparciu o prolog. ";
                case "CorrectAnswer": return
                    "\n\nByło ciężko, jednak ostatecznie udało ci się znaleźć lukę w obronie i dostać się do Szarika, który na twój widok od razu zaszczekał. " +
                    "-Spacja-";
                case "WrongAnswer": return
                    "\n\nŻołnierze wroga nie zwracali uwagi na osłonę, jaką zapewniała twoja załoga. Oddawali strzały naprzemian. W końcu jeden z nich trafił cie w kolano. Nie mogłeś nic więcej zrobić. Twoja misja dobiegła końca." +
                    "-Spacja-";
                default:
                    return "";
            }
        }
    }
}
