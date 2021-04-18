maxGoals = float('-inf')
bestPlayer = ""
hatTrick = False

while True:
    playerName = input()
    if playerName == "END":
        break

    goals = int(input())
    
    if goals > maxGoals:
        maxGoals = goals
        bestPlayer = playerName
        if goals >= 3:
            hatTrick = True
    
    if goals >= 10:
        break

print(f"{bestPlayer} is the best player!")

if hatTrick == True:
    print(f"He has scored {maxGoals} goals and made a hat-trick !!!")
else:
    print(f"He has scored {maxGoals} goals.")