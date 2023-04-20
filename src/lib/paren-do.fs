\ lib/paren-do.fs

\ This file is part of Sin Forth.

\ This file adds `(do)` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072206.
\ See change log at the end of the file.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

get-order get-current

target-definitions

: (do) ( -- do-sys )

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
