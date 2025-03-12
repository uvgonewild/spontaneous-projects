import main
import utilities
import matplotlib.pyplot as plt # pip install <- & also install Visual studio redistributable 2015 c++...
import os

# -> the main data set 
# -> used to compare the user data with gloabl data
dataset = {
    # theme : [token, rating]
    'Tech1': ['development', 0],
    'Tech2': ['programming', 0],
    'Tech3': ['cloud enginner', 0],
    'Tech4': ['coding', 0],
    'Tech5': ['web', 0],

    'Eco1': ['Economy', 0],
    'Eco2': ['Business', 0],
    'Eco3': ['Market', 0],
    'Eco4': ['Stocks', 0]
}

# plots the graph for a given category
def plotdataset(category):
    tokens = []
    ratings = []
    
    for theme, data in dataset.items():
        theme = theme.lower()
        if theme.startswith(category):
            tokens.append(data[0])
            ratings.append(data[1])

    # Create A Data Plot
    plt.figure(figsize=(10, 6))
    # Create a Bar Plot
    plt.barh(tokens, ratings, color='skyblue')

    plt.xlabel('Rating')
    plt.ylabel('Token')
    plt.title(f'{category} Category')
    plt.show()

# collects all graphs from user feed and calls the plot function
def showallgraphs():
    for theme, rate in main.userfeed.items():
        plotdataset(theme.lower())

# increments user feed and also helps in calculating user interests
def incrementUserThemes():
    # get user data
    name = utilities.getname()
    file = f'{utilities.profilepath}{name}.txt'

    if os.path.exists(file):
        requests = utilities.readfile(file)
        for request in requests:
            for targetTheme, targetRating in main.userfeed.items():
                for theme, data in dataset.items():
                    # -> Comparing user data with actual dataset
                    if data[0].lower() in request.lower():
                        if targetTheme.lower() in theme.lower(): 
                            # Change the Value of User Feed
                            main.userfeed[targetTheme] += 1

# calculates recommendation on the basis of global trends
def getrecommendation():
    highest_rating = -1
    highest_theme = ''

    highest_dataset_rate = -1
    highest_dataset_token = ''

    for theme, rating in main.userfeed.items():
        if rating > highest_rating:
            highest_rating = rating
            highest_theme = theme
            
    print(f"User Interests : {main.userfeed}\n")

    for theme, data in dataset.items():
        if highest_theme.lower() in theme.lower():
            if data[1] > highest_dataset_rate:
                highest_dataset_rate = data[1]
                highest_dataset_token = data[0]
    
    return highest_dataset_token

# increases global ratings based on all the searches made
def increaseGlobalRatings(requests):
    for request in requests:
        for theme, data in dataset.items():
            if data[0].lower() in request.lower():
                # increase the values of dataset itmes
                data[1] += 1

# get each and every request from the storage
def gatherprofiles():
    profiles = os.listdir(utilities.profilepath)
    
    for profile in profiles:
        file = f'{utilities.profilepath}{profile}'
        requests = utilities.readfile(file)

        # increase global requests on the basis of searches made
        increaseGlobalRatings(requests)

def displayDataset():
    print()
    
    for theme, data in dataset.items():
        print(f'{theme} - {data[0]} : {data[1]}')

if __name__ == '__main__':
    
    print('\n - - - - - RECOMMENDATION - - - - - ')
    print(' - - - - - - - - - - - - - - - - - -\n')

    print('1. Show Global Trends.')
    print('2. Show Indivisual Recommendation\n')

    gatherprofiles()

    while True:
        choice = input("\n:: Enter your choice : ")

        if choice == '1':

            displayDataset()
            showallgraphs()

        elif choice == '2':
            incrementUserThemes()

            print(getrecommendation())
        else:
            break

    
