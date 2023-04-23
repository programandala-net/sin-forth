\ lib/store-to.fs
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

require literal.fs \ `literal`
require store.fs   \ `!`
require tick.fs    \ `'`
require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: !> ( "name" -- )
  compiler{ ' literal }
  target{ ! } ;

  \ doc{
  \
  \ !> Compilation: ( "name" -- )
  \    Run-time:    ( x -- )
  \ "store-to"

  \
  \ Modify the value returned by a word defined by `constant`.
  \
  \ Compilation: ( "name" -- )
  \
  \ Parse _name_, which is a word created by `constant`,
  \ and compile the run-time semantics given below.
  \
  \ Run-time: ( x -- )
  \
  \ Make _x_ the current value of constant _name_.
  \
  \ // Origin: IsForth.
  \
  \ // XXX TODO
  \ // See also: `c!>`, `2!>`.
  \
  \ }doc

set-current set-order
