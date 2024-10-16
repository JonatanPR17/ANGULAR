import { RolModel } from "./rol";

export interface ProfileModel {
    id: number,
    name: string,
    lastName: string,
    mail: string,
    rol : RolModel,
    profilePictureUrl?: string;
}