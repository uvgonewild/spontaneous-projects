import utilities
import os

# Add Requests to a builtin profile
def addrequests():
    name = utilities.getname()
    file = f'{utilities.profilepath}{name}.txt'

    # if file exists
    if os.path.exists(file):
        # clear the file
        with open(file, 'w') as f:
            pass

        # write data to the file
        for i in range(3):
            request = input(f":: Enter your request {3 - i} : ")
            # FIXME: Repeat if request made is null
            utilities.writefile(file, request)
        
        print()
    else:
        print("-> Profile Not Found. \n")
        
# Show Requests of a builtin profile
def showrequests():
    name = utilities.getname()
    file = f'{utilities.profilepath}{name}.txt'

    print()

    # if file exists
    if os.path.exists(file):
        data = utilities.readfile(file)
        for d in data:
            print(':: User Request : ', d)
    else:
        print("-> File Not Found. \n")

    print()

if __name__ == '__main__':
    print("\n - - - - - REQ MANAGER - - - - -")
    print(" - - - - - - - - - - - - - - - - \n")

    print("1. Add Requests to a File.")
    print("2. Show Requests to a file. \n")

    while True:
        choice = input(":: Enter your choice : ")

        if choice == '1':
            addrequests()
        elif choice == '2':
            showrequests()
        else:
            break
