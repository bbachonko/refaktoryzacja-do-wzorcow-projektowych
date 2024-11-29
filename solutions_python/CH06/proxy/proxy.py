from abc import ABC, abstractmethod

# 1. Define the File interface
class File(ABC):
    @abstractmethod
    def get_file_content(self) -> str:
        pass

# 2a. PublicFile class
class PublicFile(File):
    def __init__(self, filename: str, content: str):
        self.filename = filename
        self.content = content

    def get_file_content(self) -> str:
        return self.content

# 2b. ProtectedFile class
class ProtectedFile(File):
    def __init__(self, filename: str, content: str, password: str):
        self.filename = filename
        self.content = content
        self.password = password

    def get_file_content(self) -> str:
        return self.content

# 3. FileProxy class
class FileProxy(File):
    def __init__(self, file: File):
        self._file = file
        self._access_granted = False

    def get_file_content(self) -> str:
        if isinstance(self._file, ProtectedFile):
            if not self._access_granted:
                self._access_granted = self.authenticate()
            if self._access_granted:
                return self._file.get_file_content()
            else:
                return "Access Denied: Incorrect Password."
        else:
            return self._file.get_file_content()

    def authenticate(self) -> bool:
        for _ in range(3):
            password = input("Enter password to access the file: ")
            if password == self._file.password:
                print("Authentication successful.\n")
                return True
            else:
                print("Incorrect password. Try again.")
                continue
        print("Maximum attempts reached. Access denied.\n")
        return False

# 4. Console-based user interface
def main():
    # Create sample files
    public_file = PublicFile("public_document.txt", "This is a public document accessible to everyone.")
    protected_file = ProtectedFile(
        filename="secret_document.txt", 
        content="This is a SECRET document. Handle with care!", 
        password="password123"
    )

    # Available files
    files = {
        "1": public_file,
        "2": protected_file
    }

    # Main loop
    while True:
        print("=== File Access System ===")
        print("Select a file to access:")
        print("1. Public Document")
        print("2. Secret Document (Protected)")
        print("3. Exit")

        choice = input("Enter your choice (1-3): ")

        if choice == "3":
            print("Exiting the application. Goodbye!")
            break
        elif choice in files:
            selected_file = files[choice]
            proxy = FileProxy(selected_file)
            content = proxy.get_file_content()
            print(f"\n--- Content of {selected_file.filename} ---")
            print(content)
            print("-----------------------------------\n")
        else:
            print("Invalid choice. Please try again.\n")


if __name__ == "__main__":
    main()
