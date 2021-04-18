number = int(input())
number = str(number)
first = int(number[2])
second = int(number[1])
third = int(number[0])

for f in range(1, first + 1):
    for s in range(1, second + 1):
        for t in range(1, third + 1):
            sum = f * s * t
            print(f"{f} * {s} * {t} = {sum};")
