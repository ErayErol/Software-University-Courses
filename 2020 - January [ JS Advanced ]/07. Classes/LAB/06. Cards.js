const result = (function () {
    let card = {
        faces: ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"],
        suits: {
            CLUBS: "\u2663",
            DIAMONDS: "\u2666",
            HEARTS: "\u2665",
            SPADES: "\u2660"
        },
    };

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(face) {
            if (card.faces.includes(face) == false) {
                throw new Error("Invalid face");
            }

            this._face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(suit) {
            if (Object.values(card.suits).indexOf(suit) === -1) {
                throw new Error("Invalid suit");
            }

            this._suit = suit;
        }
    }

    return {
        Suits: card.suits,
        Card: Card
    };
}());

let Card = result.Card;
let Suits = result.Suits;

try {
    let card = new Card("Q", Suits.CLUBS);
    card.face = "A";
    card.suit = Suits.DIAMONDS;
    let card2 = new Card("1", Suits.DIAMONDS);
} catch (error) {
    console.log(error);
}

// only submit IIFE for judge