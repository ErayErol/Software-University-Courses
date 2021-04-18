dancers = int(input())
points = float(input())
season = input()
place = input()

amountWon = dancers * points
if place == "Abroad":
    amountWon = amountWon + (amountWon / 2.0)

expenses = 0.0

if season == "summer":
    if place == "Bulgaria":
        expenses = 0.05
    elif place == "Abroad":
        expenses = 0.1
elif season == "winter":
    if place == "Bulgaria":
        expenses = 0.08
    elif place == "Abroad":
        expenses = 0.15

moneyAfterExpenses = amountWon - (amountWon * expenses)
moneyForCharity = moneyAfterExpenses - (moneyAfterExpenses * 0.25)
moneyLeft = moneyAfterExpenses - moneyForCharity
moneyPerDancer = moneyLeft / dancers

print(f"Charity - {moneyForCharity:.2f}")
print(f"Money per dancer - {moneyPerDancer:.2f}")