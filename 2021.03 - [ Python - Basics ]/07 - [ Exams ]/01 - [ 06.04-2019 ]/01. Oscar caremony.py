rentPrice = float(input())
x = rentPrice - (rentPrice - float(rentPrice * 0.7))
y = x - (x - float(x * 0.85))
z = y / 2.0

sum = rentPrice + x + y + z
print(f"{sum:.2f}")