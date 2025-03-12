import utilities
import os

# creates a file if file with same name has not been created
def createfile():
    name = utilities.getname()
    file = f'{utilities.profilepath}{name}.txt'

    # FIXME: If file name is null then return

    if not os.path.exists(file):
        with open(file, 'w'):
            print("-> File has been created Successfully.\n")
    else:
        print("-> File Already Exists. \n")

# removes a file if it exists
def removefile():
    name = utilities.getname()
    file = f'{utilities.profilepath}{name}.txt'

    if os.path.exists(file):
        os.remove(file)
        print("-> File removed successfully. \n")
    else:
        print("-> File Not Found. ")

if __name__ == '__main__':
    print("\n - - - - - REGISTERATION - - - - -")
    print(" - - - - - - - - - - - - - - - - \n")

    print("1. Create a file.")
    print("2. Delete a file. \n")

    while True:
        choice = input(":: Enter your choice : ")

        if choice == '1':
            createfile()
        elif choice == '2':
            removefile()
        else:
            break
