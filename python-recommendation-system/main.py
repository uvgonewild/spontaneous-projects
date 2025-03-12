import subprocess

# opening a file in a different console
def openfile(file):
    subprocess.Popen(['python', file], creationflags=subprocess.CREATE_NEW_CONSOLE)

# -> Stores the theme of user interests
# -> Used to Calculate User Interests
userfeed = {
    'Tech':0,
    'Eco':0
}

registeration = 'registeration.py'
recommendation = 'recommendation.py'
requestmangaer = 'requestmanager.py'

if __name__ == '__main__':

    print("\n - - - - - MAIN WINDOW - - - - -")
    print(" - - - - - - - - - - - - - - - - \n")

    print("1. Create or Delete a File.")
    print("2. Add or Show Requests. ")
    print("3. Calculate Recommendataions. \n")

    while True:
        choice = input(":: Enter your choice : ")

        if choice == '1':
            openfile(registeration)
        elif choice == '2':
            openfile(requestmangaer)
        elif choice == '3':
            openfile(recommendation)
        else:
            break
