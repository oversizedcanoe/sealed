export enum KeyType {
    Private = 1,
    Public = 2
}
  
export interface CodePair {
    privateCode: string;
    publicCode: string
}

export interface Key {
  code: string;
}

export interface KeyPair{
  privateKey: Key;
  publicKey: Key;
}

export interface UserEntry {
    text: string;
}