\ lib/paren-do.fs

\ This file is part of Sin Forth.

\ This file adds `(do)` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

get-order get-current

target-definitions

: (do) ( -- do-sys )

set-current set-order
