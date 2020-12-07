\ lib/s-p-0.fs.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

\ ==============================================================

require d-p.fs   \ `dp`
require fetch.fs \ `@`

get-order get-current

target-definitions

: here ( -- a ) dp @ ;

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
