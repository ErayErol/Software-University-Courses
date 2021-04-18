priceCpuInUsd = float(input())
priceVideoCardInUsd = float(input())
priceRamInUsd = float(input())
ramMemories = int(input())
discount = float(input())

priceCpuInLeva = priceCpuInUsd * 1.57
priceVideoCardInLeva = priceVideoCardInUsd * 1.57
pricePerRamInLeva = priceRamInUsd * 1.57
priceRamMemoriesInLeva = pricePerRamInLeva * ramMemories

priceCpuAfterDiscount = priceCpuInLeva - (priceCpuInLeva * discount)
priceVideoCardAfterDiscount = priceVideoCardInLeva - (priceVideoCardInLeva * discount)


total = priceCpuAfterDiscount + priceVideoCardAfterDiscount + priceRamMemoriesInLeva

print(f"Money needed - {total:.2f} leva.")