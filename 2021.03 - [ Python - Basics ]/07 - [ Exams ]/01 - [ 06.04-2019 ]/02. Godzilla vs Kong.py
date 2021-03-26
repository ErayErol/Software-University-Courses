budget = float(input())
extrasCount = int(input())
clothingPricePerExtra = float(input())

filmDecor = budget * 0.1
clothesTotalSum = float(clothingPricePerExtra * extrasCount)
if extrasCount > 150:
    clothesTotalSum = clothesTotalSum - (clothesTotalSum * 0.1)

filmTotalSum = filmDecor + clothesTotalSum
budget = budget - filmTotalSum
result = None

if budget >= 0:
    result = f"Action!\nWingard starts filming with {budget:.2f} leva left."
else :
    budget = budget - (budget - abs(budget))
    result = f"Not enough money!\nWingard needs {budget:.2f} leva more."

print(result)
