studentTickets = 0
standardTickets = 0
kidTickets = 0
sumTickets = 0

while True:
    filmName = input()
    if filmName == "Finish":
        break

    freePlaces = int(input())
    ticketsBought = 0
    
    for i in range(freePlaces):
        typeOfTicket = input()

        if typeOfTicket == "End":
            break
        elif typeOfTicket == "student":
            studentTickets+=1
        elif typeOfTicket == "standard":
            standardTickets+=1
        elif typeOfTicket == "kid":
            kidTickets+=1

        ticketsBought+=1
        sumTickets+=1

    reserved = (ticketsBought / freePlaces) * 100
    print(f"{filmName} - {reserved:.2f}% full.")


reservedStudent = (studentTickets / sumTickets) * 100
reservedStandard = (standardTickets / sumTickets) * 100
reservedKid = (kidTickets / sumTickets) * 100

print(f"Total tickets: {sumTickets}")
print(f"{reservedStudent:.2f}% student tickets.")
print(f"{reservedStandard:.2f}% standard tickets.")
print(f"{reservedKid:.2f}% kids tickets.")