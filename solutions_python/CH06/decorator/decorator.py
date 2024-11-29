from functools import wraps

# -------------------------------
# 1. Function Decorators
# -------------------------------

def sms_notification(func):
    @wraps(func)
    def wrapper(self, amount, *args, **kwargs):
        result = func(self, amount, *args, **kwargs)
        print(f"SMS Notification: You have successfully paid ${amount:.2f}.")
        return result
    return wrapper

def loyalty_points(func):
    @wraps(func)
    def wrapper(self, amount, *args, **kwargs):
        result = func(self, amount, *args, **kwargs)
        points = int(amount)  # 1 point per dollar
        print(f"Loyalty Points: {points} points added to your account.")
        return result
    return wrapper

def redirect_home(func):
    @wraps(func)
    def wrapper(self, amount, *args, **kwargs):
        result = func(self, amount, *args, **kwargs)
        print("Redirecting to the shop's homepage.")
        return result
    return wrapper

# -------------------------------
# 2. Shop Class
# -------------------------------

class Shop:
    def pay_cash(self, amount: float):
        print(f"Processing cash payment of ${amount:.2f}.")

    @sms_notification
    @loyalty_points
    @redirect_home
    def pay_card(self, amount: float):
        """Processes card payment and triggers decorators."""
        print(f"Processing card payment of ${amount:.2f}.")

    def pay_ewallet(self, amount: float):
        print(f"Processing e-wallet payment of ${amount:.2f}.")

# -------------------------------
# 3. User Interface
# -------------------------------

def main():
    shop = Shop()
    while True:
        print("=== Welcome to the Shop ===")
        print("Select a payment method:")
        print("1. Cash")
        print("2. Card")
        print("3. E-Wallet")
        print("4. Exit")

        choice = input("Enter your choice (1-4): ")

        if choice == '4':
            print("Thank you for visiting. Goodbye!")
            break
        elif choice in ['1', '2', '3']:
            amount_str = input("Enter the amount to pay: ")
            try:
                amount = float(amount_str)
                if amount <= 0:
                    print("Amount must be positive.\n")
                    continue
            except ValueError:
                print("Invalid amount entered. Please enter a numeric value.\n")
                continue

            print()

            if choice == '1':
                shop.pay_cash(amount)
            elif choice == '2':
                shop.pay_card(amount)
            else:
                shop.pay_ewallet(amount)

            print()
        else:
            print("Invalid choice. Please try again.\n")


if __name__ == "__main__":
    main()
