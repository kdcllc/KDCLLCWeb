// Compiled using typings@0.6.9
// Source: https://raw.githubusercontent.com/DefinitelyTyped/DefinitelyTyped/bd269cad4cb2b495f940c7b6afc5825d568029be/wrench/wrench.d.ts
// Type definitions for wrench
// Project: https://github.com/ryanmcgrath/wrench-js
// Definitions by: Carlos Ballesteros Velasco <https://github.com/soywiz>
// Definitions: https://github.com/borisyankov/DefinitelyTyped

// Imported from: https://github.com/soywiz/typescript-node-definitions/wrench.d.ts

declare module "wrench" {
	export function readdirSyncRecursive(baseDir: string): string[];
	export function rmdirSyncRecursive(path: string, failSilent?: boolean): void;
	export function copyDirSyncRecursive(sourceDir: string, newDirLocation: string, opts?: { preserve?: boolean; }): void;
	export function chmodSyncRecursive(sourceDir: string, filemode: number): void;
	export function chownSyncRecursive(sourceDir: string, uid: number, gid: number): void;
	export function mkdirSyncRecursivefunction(path: string, mode: number): void;

	export function readdirRecursive(baseDir: string, fn: (err: Error, files: string[]) => void): void;
	export function rmdirRecursive(path: string, fn: (err: Error) => void): void;
	export function copyDirRecursive(srcDir: string, newDir: string, fn: (err: Error) => void): void;

	export class LineReader {
		constructor (filename: string, bufferSize?: number);

		getBufferAndSetCurrentPosition(position: number): number;
		hasNextLine(): boolean;
		getNextLine(): string;
	}
}