\ Sin Forth

\ A Forth System, written in ANS Forth,
\ that compiles Z80 assembler for the Sinclair ZX Spectrum.

\ Copyright (C) 2010 Marcos Cruz (http://programandala.net)

\ History

\ 2010-04-21 First concrete ideas.

only forth definitions

vocabulary meta
also meta definitions

\ : ! ( a n -- )
\ 	swap 2dup 256 mod swap c! 256 / swap 1+ c!
\ ;


decimal

27000 constant origin
variable target_ram_size
65535 origin - target_ram_size !

variable target_ram
: ram_space ( -- a )
	target_ram_size @ allocate
	abort" Allocate error"
;
ram_space target_ram !




vocabulary system
also system definitions



\ Source code of the ZX Spectrum program



