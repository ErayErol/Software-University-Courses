budget = int(input())

filmCount = 0
productCount = 0
sum = float(0.0)
while budget >= 0:
    inputValue = input()

    if inputValue == "End":
        break

    budgetAfterBought = 0
    if len(inputValue) > 8:
        sum = int(ord(inputValue[0])) + int(ord(inputValue[1]))
        budgetAfterBought = budget - sum
        if budgetAfterBought >= 0:
            filmCount = filmCount + 1
    else:
        sum = int(ord(inputValue[0]))
        budgetAfterBought = budget - sum
        if budgetAfterBought >= 0:
            productCount = productCount + 1

    budget = budgetAfterBought

print(filmCount)
print(productCount)