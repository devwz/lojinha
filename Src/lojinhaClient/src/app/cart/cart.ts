export interface Item {
    id: number;
    imgUrl: string;
    price: number;
    title: string;
    unid: number;
}

export interface Cart {
    id: number;
    cartKey: string;
    itemCollection: Item[];
}