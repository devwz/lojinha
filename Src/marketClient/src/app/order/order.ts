import { Cart } from '../cart/cart';

export interface Order {
    id: number;
    cart: Cart;
    client: Client;
}

export interface Client {
    id: number;
    name: string;
    surname: string;
    email: string;
    address: Address;
}

export interface Address {
    id: number;
    addressLine: string;
    countryRegion: string;
    postalCode: string;
    stateProvince: string;
}