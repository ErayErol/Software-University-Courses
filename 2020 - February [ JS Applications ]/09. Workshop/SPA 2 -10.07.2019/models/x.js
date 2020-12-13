export default {
    createDocument(data) {
        return firebase.firestore().collection("causes").add(data);
    },
    getAll() {
        return firebase.firestore().collection("causes").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("causes").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("causes").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("causes").doc(id).update(data);
    },
};