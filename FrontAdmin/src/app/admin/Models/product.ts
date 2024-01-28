import { ProductTextAttribute, TextAttribute } from "./productAttribute";

export interface Product {
    id: number;
    name: string;
    textAttributeVMs: ProductTextAttribute[];
}