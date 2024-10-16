import { ImageModel } from "./image"

export interface ProductServiceModel {
    id: number,
    name: string,
    type: string,
    description: string,
    price: number,
    stock : number,
    image : ImageModel,
    state: boolean,
    brand: string,
    category: string
}

