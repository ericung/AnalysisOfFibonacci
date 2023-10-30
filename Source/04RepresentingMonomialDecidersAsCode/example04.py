# Representing the monomial decider 2x^2
def md2xx2(y):
    #opening = "Now deciding: " + str(y)
    #print(opening)
    if y == 0:
        return True
    s = y
    while (s >= 0):
        for i in range(2):
            for j in range(4):
                if (s == 0 and (j == 0 or j == 2) and i == 0):
                    return True
                elif (s < 0):
                    break
                s -= 1
    return False

d = 0
x = 0
for t in range(1001):
    if (md2xx2(t) == True):
        num = 2 * (x^2)
        print("f("+ str(x) + ") = " + str(t) + " = " + str(num))
        x += 1
