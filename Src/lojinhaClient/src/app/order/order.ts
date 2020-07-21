import { Cart } from '../cart/cart';

export interface Order {
    cart: Cart;
    client: Client;
}

export interface Client {
    name: string;
    surname: string;
    email: string;
    address: Address;
}

export interface Address {
    addressLine: string;
    countryRegion: string;
    postalCode: string;
    stateProvince: string;
}