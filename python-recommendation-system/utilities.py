
profilepath = 'profiles/'

def getname():
    name = input(":: Enter your name : ")
    return name

# reads all the data from a file
def readfile(file):
    data = []
    with open(file, 'r') as f:
        data = f.readlines()
    return data

# adds a particular request to a file
def writefile(file, request):
    with open(file, 'a') as f:
        f.write(f"{request}\n")
