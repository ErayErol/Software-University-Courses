export default {
    register(username, password) {
        return firebase.auth().createUserWithEmailAndPassword(username, password);
    },
    login(username, password) {
        return firebase.auth().signInWithEmailAndPassword(username, password);
    },
    logout() {
        return firebase.auth().signOut();
    }
};