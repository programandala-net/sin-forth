\ lib/here.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-p.fs   \ `dp`
require fetch.fs \ `@`

get-order get-current

target-definitions

: here ( -- a ) dp @ ;

  \ doc{
  \
  \ here ( -- a )
  \
  \ Return the data-space pointer _a_.
  \
  \ // XXX TODO
  \ // See also: `dp`, `limit`, `unused`, `there`.
  \ See also: `dp`.
  \
  \ }doc

set-current set-order
