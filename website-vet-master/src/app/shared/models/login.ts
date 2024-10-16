import { ProfileModel } from "./profile"

export interface LoginModel {
    main: string,
    password: string,
}

export interface LoginResponse {
    token: string
    profile: ProfileModel
  }