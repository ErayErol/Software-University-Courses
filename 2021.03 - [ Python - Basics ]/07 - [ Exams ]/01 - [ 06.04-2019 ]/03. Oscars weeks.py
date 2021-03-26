filmName = input()
filmType = input()
ticketsBought = int(input())

price = float(0.0)

if filmName == "A Star Is Born":
    if filmType == "normal":
        price = 7.50
    elif filmType == "luxury":
        price = 10.50
    elif filmType == "ultra luxury":
        price = 13.50 
elif filmName == "Bohemian Rhapsody":
    if filmType == "normal":
        price = 7.35
    elif filmType == "luxury":
        price = 9.45
    elif filmType == "ultra luxury":
        price = 12.75
elif filmName == "Green Book":
    if filmType == "normal":
        price = 8.15
    elif filmType == "luxury":
        price = 10.25
    elif filmType == "ultra luxury":
        price = 13.25
elif filmName == "The Favourite":
    if filmType == "normal":
        price = 8.75
    elif filmType == "luxury":
        price = 11.55
    elif filmType == "ultra luxury":
        price = 13.95

sum = ticketsBought * price
print(f"{filmName} -> {sum:.2f} lv.")