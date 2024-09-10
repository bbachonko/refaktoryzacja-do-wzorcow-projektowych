## Test coverage

1. Zbuduj projekt `GildedRose`.
2. W menu VisualStudio przejdź do zakładki `Extensions\ReSharper\Cover`.
3. Uruchom `Cover Application`.
4. Wybierz `New Process Run` i opcje `Standalone`.
5. Wskaż ścieżkę do wybudowanego projektu, może być debug np. `refaktoryzacja-do-wzorcow-projektowych\CH03_RefactoringWithTests\GildedRose\bin\Debug\net8.0` i plik `GildedRose.exe`.
6. Run analysis.

## Refactoring

1. Zidentyfikuj miejsce, które wymaga szczególnej uwagi i rozpocznij refaktoryzację.
1. Testy jednostkowe są przygotowane ale jeżeli masz cheć dopisz własne.
1. Kilka porad, rozpocznij od dodania wzorca Guard Clauses https://www.refactoring.com/catalog/replaceNestedConditionalWithGuardClauses.html
1. Uprość metodę UpdateQuality(), zastępując zagnieżdżone bloki warunkowe instrukcjami strażników.
1. Wydziel logikę specyficzną dla różnych przedmiotów do osobnych metod.
1. Zidentyfikuj kod specyficzny dla różnych typów przedmiotów w metodzie UpdateQuality() i wydziel go do osobnych klas strategii. Każdy typ przedmiotu będzie miał swoją klasę strategii odpowiedzialną za aktualizację jakości.
1. Wydziel kod specyficzny dla Aged Brie, Backstage passes, Sulfuras itp. do osobnych klas.
1. Stwórz interfejs IItemStrategy z metodą Update(Item item).
1. Zastąp logikę w metodzie UpdateQuality() mechanizmem wyboru odpowiedniej strategii.
1. Faktoryzację przeprowadzaj w małych krokach.
1. Po każdej gotowej zmianie uruchom testy.