\ lib/comma.fs.fs

\ This file is part of Sin Forth.

\ This file adds `,` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

\ ==============================================================

require here.fs  \ `here`
require store.fs \ `!`
require cell.fs  \ `cell`
require allot.fs \ `allot`

get-order get-current

target-definitions

: , ( x -- ) here ! cell allot ;

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.

