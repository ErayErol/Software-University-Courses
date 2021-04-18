students = int(input())

grupa1 = 0
grupa2 = 0
grupa3 = 0
grupa4 = 0

sum = 0.0

for i in range(students):
    grade = float(input())

    if grade >= 5.00:
        grupa1+=1
    elif (grade >= 4.00) and (grade <= 4.99):
        grupa2+=1
    elif (grade >= 3.00) and (grade <= 3.99):
        grupa3+=1
    elif grade < 3.00:
        grupa4+=1

    sum += grade

topStudents = (grupa1 / students) * 100
between4And5 = (grupa2 / students) * 100
between3And4 = (grupa3 / students) * 100
fail = (grupa4 / students) * 100
average = sum / students

print(f"Top students: {topStudents:.2f}%")
print(f"Between 4.00 and 4.99: {between4And5:.2f}%")
print(f"Between 3.00 and 3.99: {between3And4:.2f}%")
print(f"Fail: {fail:.2f}%")
print(f"Average: {average:.2f}")