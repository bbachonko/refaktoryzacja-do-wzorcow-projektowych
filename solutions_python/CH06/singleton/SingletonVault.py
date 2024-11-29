import random


class VaultSingleton(object):
    def __new__(cls):
        """ creates a singleton object, if it is not created, 
        or else returns the previous singleton object"""
        if not hasattr(cls, 'instance'):
            cls.instance = super(VaultSingleton, cls).__new__(cls)
        return cls.instance

    def __init__(self) -> None:
        if not hasattr(self, "key_generated"):
            self.key_generated = False
            self.vault_key: int = None    

    def _generate_vault_key(self) -> int | str:
        if not self.key_generated:
            self.vault_key = random.randint(1000, 9999)
            self.key_generated = True
            return self.vault_key
        return "Value was already generated"
    
    def get_key_vault(self):
        return self._generate_vault_key()
        


if __name__ == "__main__":
    vaultsingleton = VaultSingleton()
    vaultsingleton_duplicated = VaultSingleton()
    key = vaultsingleton.get_key_vault()
    print(key)

    another_key = vaultsingleton.get_key_vault()
    print(another_key)

    assert vaultsingleton == vaultsingleton_duplicated, "Instances are not the same"
    print(vaultsingleton_duplicated == vaultsingleton)