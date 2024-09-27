from abc import ABC, abstractmethod
from typing import Union

class Wojownik(ABC):
    def __str__(self) -> str:
        return f"Jestem wojownikiem. \
            Moja profesja to {self.__class__.__name__}"
    
class Piechur(Wojownik):
    pass

class Strzelec(Wojownik):
    pass

class Konny(Wojownik):
    pass

class Garnizon:
    @staticmethod
    def train_warrior(
        profession: str) -> Union[Piechur, Strzelec, Konny]:
        """
        Ta metoda tworzy/zwraca konrketna intnacje w zaelznosci od danego inputu.
        """
        match profession:
            case "Piechur":
                return Piechur()
            case "Strzelec":
                return Strzelec()
            case "Konny":
                return Konny()
            case _:
                raise ValueError("Wrong input.")
            

if __name__ == "__main__":
    garnizon = Garnizon()

    print(garnizon.train_warrior("Konny"))
    print(garnizon.train_warrior("Strzelec"))
    print(garnizon.train_warrior("Piechur"))
    print("\n\n")

    warriors_list = [Piechur()] * 3 + \
                    [Konny()] * 3 + \
                    [Strzelec()] * 4
    [print(warrior) for warrior in warriors_list]