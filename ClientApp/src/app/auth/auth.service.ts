import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  currentuser?: User
  loginUser(user: User) {
    console.log("Log in user with email "+ user.email);
    this.currentuser = user
  }
}

interface User{
  email: string
}
