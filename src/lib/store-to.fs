\ lib/store-to.fs

\ This file is part of Sin Forth.

\ This file adds `!>` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012110236.
\ See change log at the end of the file.

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
  \ !> Compiler: ( "name" -- )
  \    Run-time: ( x -- )
  \ "store-to"

  \
  \ Modify the value returned by a word defined by `constant`.
  \
  \ Compiler: ( "name" -- )
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

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start definition of `to`, to be used with `value`.
\
\ 2020-12-11: Update the search-order selection words. Rename from
\ `to` to `!>`, because the definition of `value` is identical to
\ `constant`. `!>` is included in Solo Forth, which borrowed the idea
\ from IsForth.
