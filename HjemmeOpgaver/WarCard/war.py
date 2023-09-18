#     deck2.append(filter(input().replace("10","T")))
deck1=[]
deck2=[]
cards = ["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"]
for i in range(int(input())):
    deck1.append(cards.index(input().replace("10","T")[:-1]))
for i in range(int(input())):
    deck2.append(cards.index(input().replace("10","T")[:-1]))

plays=0
pot1, pot2=[],[]


while(True):
    card1=deck1.pop(0)
    card2=deck2.pop(0)
    if card1!=card2: #if not same card
        pot1.append(card1)
        pot2.append(card2)
        if (card1>card2): #battle, player 1 cards higher
            deck1.extend(pot1+pot2) #add to player 1 deck
        else:
            deck2.extend(pot1+pot2) #if player 2 higher, add to player 2 deck 
        plays+=1
        pot1, pot2=[],[] #reset pot's
        if len(deck2)==0:   #if deck is empty
            print(f"1 {plays}")
        elif len(deck1)==0:     #if deck is empty
            print(f"2 {plays}")
    elif len(deck1)<3 or len(deck2)<3: #if not possible to do continue war
        print("PAT") #let both win
        break
    else: #do war
        pot1.append(card1)
        pot2.append(card2)
        for _ in range(3): #put next 3 cards in pot's
            pot1.append(deck1.pop(0))
            pot2.append(deck2.pop(0))