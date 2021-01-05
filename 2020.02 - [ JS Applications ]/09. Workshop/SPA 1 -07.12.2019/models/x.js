export default {
    createDocument(data) {
        return firebase.firestore().collection("treks").add(data);
    },
    getAll() {
        return firebase.firestore().collection("treks").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("treks").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("treks").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("treks").doc(id).update(data);
    },
};