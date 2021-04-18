filmCount = int(input())

highestRating = float('-inf')
highestRatingName = ""
lowestRating = float('inf')
lowestRatingName = ""

sum = 0.0

for i in range(filmCount):
    filmName = input()
    filmRating = float(input())

    sum = sum + filmRating

    if filmRating > highestRating:
        highestRating = filmRating
        highestRatingName = filmName

    if filmRating < lowestRating:
        lowestRating = filmRating
        lowestRatingName = filmName

print(f"{highestRatingName} is with highest rating: {highestRating:.1f}")
print(f"{lowestRatingName} is with lowest rating: {lowestRating:.1f}")
average = sum / filmCount
print(f"Average rating: {average:.1f}")