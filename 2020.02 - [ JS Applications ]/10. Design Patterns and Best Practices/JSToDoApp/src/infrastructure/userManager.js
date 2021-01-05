import 'firebase/auth';
import * as toastr from 'toastr';

export default class UserManager {
    constructor(app){
        this.auth = app.auth();
    }

    async createUser(email, password){
        return this.auth.createUserWithEmailAndPassword(email, password);
    }

    async signIn(email, password){
        return this.auth.signInWithEmailAndPassword(email, password);
    }

    async signOut(){
        return this.auth.signOut();
    }

    getCurrentUser(){
        return this.auth.currentUser;
    }

    async updateUser(name, photoUrl){
        let user = this.getCurrentUser();

        if (user) {
            let newName = name || user.displayName;
            let newPhoto = photoUrl || user.photoURL;

            return user.updateProfile(newName, newPhoto);
        }

        throw Error('Sign in first!');
    }

    async updateEmail(email) {
        let user = this.getCurrentUser();

        if (user) {
            let newEmail = email || user.email;

            return user.updateEmail(newEmail);
        }

        throw Error('Sign in first!');
    }

    setObserver(containerId){
        this.auth.onAuthStateChanged(function(user) {
            const element = document.getElementById(containerId);
            const authorizedElements = document.querySelectorAll('.must-authenticate');

            if (user) {
              // User is signed in.
              toastr.success(`Hi, ${user.email}! You are in!`);
              element.innerHTML = '<a class="nav-link" href="/account/logout">Logout</a>';
              authorizedElements.forEach((e) => e.removeAttribute('hidden'));
            } else {
              // User is signed out.
              if (document.location.pathname.includes('logout')) {
                toastr.info(`Good bye!`);
              }
              
              element.innerHTML = '<a class="nav-link" href="/account/login">Login</a>';
              authorizedElements.forEach((e) => e.setAttribute('hidden', true));
            }
          });
    }
}