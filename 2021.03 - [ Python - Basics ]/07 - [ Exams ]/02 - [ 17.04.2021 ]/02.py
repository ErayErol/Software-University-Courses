import math

days = int(input())
foodLeave = int(input())
foodFor1Deer = float(input())
foodFor2Deer = float(input())
foodFor3Deer = float(input())

deer1 = days * foodFor1Deer
deer2 = days * foodFor2Deer
deer3 = days * foodFor3Deer

totalFood = deer1 + deer2 + deer3
foodLeft = foodLeave - totalFood

if foodLeft >= 0:
    result = f"{math.floor(foodLeft)} kilos of food left."
else :
    foodNeeded = totalFood - foodLeave
    result = f"{math.ceil(foodNeeded)} more kilos of food are needed."
print(result)