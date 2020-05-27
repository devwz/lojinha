export interface Cart {
    cartKey: string;
    item: CartItem[];
}

export interface CartItem {
    id: number;
    unid: number;
}