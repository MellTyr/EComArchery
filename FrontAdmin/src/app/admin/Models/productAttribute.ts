export interface TextAttribute {
    id: number;
    name: string;
    attributeType: attributeType;
}

export interface TextValue {
    id: number;
    text: string;
}

export interface ProductTextAttribute extends TextAttribute {
    value: TextValue
}

export interface productChoiseAttribute {
    id: number;
    name: string;
    attributeType: attributeType;
}

export interface choiseAttribute {
    id:number;
    name: string;
    values: choiseAttributeValue[];
}

export interface choiseAttributeValue {
    id: number;
    value: string;
}

export enum attributeType {
    text = 1,
    choise = 2,
}