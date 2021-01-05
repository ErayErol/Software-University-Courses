function playingCards(face, suit) {
    let card = {
        faces: ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"],
        suits: {
            S: "\u2660",
            H: "\u2665",
            D: "\u2666",
            C: "\u2663"
        },

    };

    if (card.faces.includes(face) && card.suits[suit]) {
        return face + card.suits[suit];
    } else {
        throw new Error();
    }
}

console.log(playingCards('A', 'S'));
console.log(playingCards('10', 'H'));
console.log(playingCards('1', 'C'));